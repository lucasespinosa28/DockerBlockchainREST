# DockerBlockchainREST
I did this project to Binance hackathon, DockerBlockchainREST lets you turn the smart contract into Api
## How to use this 
- First, create an ABI.json with contract Abi
- Run it➜ docker run --rm -it -p 8080:80 -p 8443:443 -v {folder with abi.json}:/app/wwwroot/storage lucasespinosa/dockerblockchainrest --address {contract address}

it's will create an api with using a smart contract in Binance smart chain with documentation with swagger ui

# [Samples with website using the Api](https://github.com/lucasespinosa28/DockerBlockchainREST/tree/master/samples).
