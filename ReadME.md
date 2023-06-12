### Build docker image

*docker client must be run*

Run at the ./GrpcRandomNumbersClient path of the project:

        docker build -t grpcrandomnumbersclient:1.0 ./

### Run container

Then run the container:

        docker run grpcrandomnumbersclient:1.0 

You can run containers as much as you want. 

A client does 100 requests with a delay of 100 ms and then repeats it 10 times with a delay of 1 s.