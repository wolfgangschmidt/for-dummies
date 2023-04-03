# Description

this is a video feed upscales. 
in the present inplementation it assumes a 720p default video camera and will upscale it to 1080p

# run code and compile

this assumes you have all dependencies installed on your system (opencv, c++, and cuda nvidia toolkit)

## compile
- ```nvcc -I/usr/local/cuda/include -I/usr/include/opencv4 -L/usr/local/cuda/lib64 -L/usr/lib/x86_64-linux-gnu -o upscale upscale.cpp `pkg-config --libs opencv4` -lcudart -lcudnn ```

## run

` ./upscale `



## **system info**

this was compiled on a fedor linux system with 32gb ram and a nvidia gtx-1080TI video card.

## **installation process**

  sudo dnf install g++

  ``` 
  wget https://developer.download.nvidia.com/compute/cuda/12.1.0/local_installers/cuda-repo-fedora37-12-1-local-12.1.0_530.30.02-1.x86_64.rpm 
  
  ```
  
  ` look for lates are compatible version for your system `

  sudo rpm -i cuda-repo-fedora37-12-1-local-12.1.0_530.30.02-1.x86_64.rpm

  sudo dnf -y module install nvidia-driver:latest-dkms
  sudo dnf -y install cuda

  sudo dnf -y module install nvidia-driver:latest-dkms
  sudo dnf -y install cuda

  export PATH=$PATH:/usr/local/cuda/bin
  source ~/.bashrc


  sudo dnf update
  sudo dnf install opencv-devel
  pkg-config --libs opencv

## **export lib paths**
 this path may vary from system to system

```
export LD_LIBRARY_PATH=$LD_LIBRARY_PATH:/usr/local/cuda/targets/x86_64-linux/lib
```

