import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import Cake from './Cake';
import Charts from './Charts';
import Wbnb from './Wbnb'
import reportWebVitals from './reportWebVitals';

ReactDOM.render(
    <React.StrictMode>
    <div class="justify-self-center p-4  shadow-md my-8">
            <h1 class="text-3xl font-bold text-yellow-500 text-center">Chainlink oracle bnb/usd turned into rest api</h1>
            <div class="justify-self-center px-8 shadow-md my-2" >
                <p class="font-semibold text-purple-600 ">docker run <span class="text-purple-800">--rm</span>
                    <span class="text-purple-800">-it</span>  <span class="text-purple-800">-p</span>  8110:80
                    <span class="text-purple-800">-p</span>  8111:443 <span class="text-purple-800">-v</span>
                    <span class="text-green-800">$(pwd)/docker/bnbusd</span>:/app/wwwroot/storage  lucasespinosa/dockerblockchainrest
                    <span class="text-purple-800">--address</span>0x0567F2323251f0Aab15c8dFb1967E4e8A7D42aeE</p>
        </div>
        <div class="justify-self-center px-8 shadow-md my-2">
            <p class="font-semibold"><a href="http://localhost:8111/api/readcontract/latestanswer">http://localhost:8111/api/readcontract/latestanswer</a></p>
        </div>
        <App />
    </div>
    <div class="justify-self-center p-4  shadow-md my-8">
        <h1 class="text-3xl font-bold text-yellow-500 text-center">Show the list of transactions wbnb</h1>
        <div class="justify-self-center px-8 shadow-md my-2" >
                <p class="font-semibold text-purple-600 ">docker run <span class="text-purple-800">--rm</span>
                    <span class="text-purple-800">-it</span>  <span class="text-purple-800">-p</span>  8220:80
                    <span class="text-purple-800">-p</span>  8222:443 <span class="text-purple-800">-v</span>
                    <span class="text-green-800">$(pwd)/docker/wbnb</span>:/app/wwwroot/storage  lucasespinosa/dockerblockchainrest
                    <span class="text-purple-800">--address</span>  xbb4CdB9CBd36B01bD1cBaEBF2De08d9173bc095c</p>
        </div>
        <div class="justify-self-center px-8 shadow-md my-2">
            <p class="font-semibold"><a href="http://localhost:8111/api/readcontract/latestanswer">http://localhost:8111/api/readcontract/latestanswer</a></p>
            </div>
            <Wbnb/>
    </div>
    <div class="justify-self-center p-4  shadow-md my-8">
            <h1 class="text-3xl font-bold text-yellow-500 text-center">CAKE-BNB LP contract turned into rest api</h1>
        <div class="justify-self-center px-8 shadow-md my-2" >
                <p class="font-semibold text-purple-600 ">docker run <span class="text-purple-800">--rm</span> <span class="text-purple-800">-it</span>
                    <span class="text-purple-800">-p</span>  8330:80 <span class="text-purple-800">-p</span>  8333:443
                    <span class="text-purple-800">-v</span>  <span class="text-green-800">$(pwd)/docker/cakebnb</span>:/app/wwwroot/storage  lucasespinosa/dockerblockchainrest
                    <span class="text-purple-800">--address</span>  0xA527a61703D82139F8a06Bc30097cC9CAA2df5A6 </p>
        </div>
        <div class="justify-self-center px-8 shadow-md my-2">
                <p class="font-semibold"><a href="http://localhost:8330/api/event/Swap?NumberBlocks=5">http://localhost:8330/api/event/Swap?NumberBlocks=5</a></p>
            </div>
            <Cake />
    </div>
  </React.StrictMode>,
  document.getElementById('root')
);
// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
