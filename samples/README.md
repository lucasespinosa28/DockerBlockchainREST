# Sample file with website using Api running at docker container

you will need to run 3 dockers containers 
### `docker run --rm-it -p 8110:80-p 8111:443 -v$(pwd)/docker/bnbusd:/app/wwwroot/storage lucasespinosa/dockerblockchainrest --address 0x0567F2323251f0Aab15c8dFb1967E4e8A7D42aeE`
### `docker run --rm-it -p 8220:80-p 8222:443 -v$(pwd)/docker/wbnb:/app/wwwroot/storage lucasespinosa/dockerblockchainrest --address xbb4CdB9CBd36B01bD1cBaEBF2De08d9173bc095c`
### `docker run --rm -it-p 8330:80 -p 8333:443-v $(pwd)/docker/cakebnb:/app/wwwroot/storage lucasespinosa/dockerblockchainrest --address 0xA527a61703D82139F8a06Bc30097cC9CAA2df5A6`
### `npm start`

Runs the app in the development mode.\
Open [http://localhost:3000](http://localhost:3000) to view it in the browser.

The page will reload if you make edits.\
You will also see any lint errors in the console.


