#include <iostream>
#include <cuda_runtime.h>
#include "/usr/local/cuda/include/cudnn.h"
#include "/usr/include/opencv4/opencv2/opencv.hpp"

#define BATCH_SIZE 1
#define CHANNELS 3
#define HEIGHT 720
#define WIDTH 1280


using namespace std;

int main() {
    cudnnHandle_t cudnn;
    cudnnCreate(&cudnn);

    cudaStream_t stream;
    cudaStreamCreate(&stream);

    cudnnTensorDescriptor_t inputDesc;
    cudnnCreateTensorDescriptor(&inputDesc);
    cudnnSetTensor4dDescriptor(inputDesc, CUDNN_TENSOR_NCHW, CUDNN_DATA_FLOAT, BATCH_SIZE, CHANNELS, HEIGHT, WIDTH);

    cudnnTensorDescriptor_t outputDesc;
    cudnnCreateTensorDescriptor(&outputDesc);
    cudnnSetTensor4dDescriptor(outputDesc, CUDNN_TENSOR_NCHW, CUDNN_DATA_FLOAT, BATCH_SIZE, CHANNELS, HEIGHT*2, WIDTH*2);

    cudnnFilterDescriptor_t filterDesc;
    cudnnCreateFilterDescriptor(&filterDesc);
    cudnnSetFilter4dDescriptor(filterDesc, CUDNN_DATA_FLOAT, CUDNN_TENSOR_NCHW, CHANNELS, CHANNELS, 3, 3);

    cudnnConvolutionDescriptor_t convDesc;
    cudnnCreateConvolutionDescriptor(&convDesc);
    cudnnSetConvolution2dDescriptor(convDesc, 1, 1, 1, 1, 1, 1, CUDNN_CROSS_CORRELATION, CUDNN_DATA_FLOAT);

    int inputSize = BATCH_SIZE * CHANNELS * HEIGHT * WIDTH;
    int outputSize = BATCH_SIZE * CHANNELS * HEIGHT * 2 * WIDTH * 2;

    float* inputPtr;
    cudaMalloc(&inputPtr, inputSize * sizeof(float));

    float* outputPtr;
    cudaMalloc(&outputPtr, outputSize * sizeof(float));


    cv::VideoCapture cap(0);
    if (!cap.isOpened()) {
        cerr << "Failed to open camera!" << endl;
        return -1;
    }

    cv::Mat frame;
    while (cap.read(frame)) {
        cv::resize(frame, frame, cv::Size(WIDTH, HEIGHT));

        cudaMemcpyAsync(inputPtr, frame.data, WIDTH * HEIGHT , cudaMemcpyHostToDevice, stream);

        float alpha = 1.0f;
        float beta = 0.0f;
        cudnnConvolutionForward(cudnn, &alpha, inputDesc, inputPtr, filterDesc, outputPtr, convDesc, CUDNN_CONVOLUTION_FWD_ALGO_IMPLICIT_GEMM, nullptr, 0, &beta, outputDesc, outputPtr);

        cv::Mat outputMat(HEIGHT*2, WIDTH*2, CV_32FC3);
        cudaMemcpyAsync(outputMat.data, outputPtr, WIDTH * HEIGHT, cudaMemcpyDeviceToHost, stream);

        cv::imshow("Input", frame);
        cv::imshow("Output", outputMat);
        if (cv::waitKey(1) == 27) {
            break;
        }
    }

    cudaFree(inputPtr);
    cudaFree(outputPtr);

    cudnnDestroyTensorDescriptor(inputDesc);
    cudnnDestroyTensorDescriptor(outputDesc);
    cudnnDestroyFilterDescriptor(filterDesc);
    cudnnDestroyConvolutionDescriptor(convDesc);

    cudnnDestroy(cudnn);
    cudaStreamDestroy(stream);

    return 0;
}
