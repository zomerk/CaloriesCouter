docker stop asp

docker build -t asp .

docker run -d -p 8080:8080 --name asp asp 