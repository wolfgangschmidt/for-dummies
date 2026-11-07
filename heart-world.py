msg = "hello world " * 2

for i in range(len(msg)):
    if i == 0:
        for j in [6,4,3,2,1]:
            top = ("  " * j + msg[:j*-1] + " " + msg[:7-j])
            print( top * 2 + msg[-7+j:])
    else:
        print(" " * i, msg[i:] + msg[i-1:]*2)

