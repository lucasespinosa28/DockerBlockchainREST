import logo from './logo.svg';
import './App.css';
import { AxiosProvider, Request, Get, Delete, Head, Post, Put, Patch, withAxios } from 'react-axios'

function Wbnb() {
  return (
      <div>
          <Get url="http://localhost:8111/api/readcontract/latestAnswer">
              {(error, response, isLoading, makeRequest, axios) => {
                  if (error) {
                      return (<div>Something bad happened: {error.message} <button onClick={() => makeRequest({ params: { reload: true } })}>Retry</button></div>)
                  }
                  else if (isLoading) {
                      return (<div>Loading...</div>)
                  }
                  else if (response !== null) {
                      return (
                          <div className="flex  justify-center flex-row font-semibold text-3xl text-center">
                              <h3 className="text-yellow-400 p-2  shadow-md">BNB</h3>
                              <span className="text-gray-800 p-2"> / </span>
                              <h3 className="text-green-600 p-2 shadow-md">USD</h3>
                              <span className="text-gray-800 p-2"> : </span>
                              <h3 className="p-2 shadow-md">${response.data.result.slice(0, 3) + ","+response.data.result.slice(2, 4)}</h3>
                          </div>)
                  }
                  return (<div>Default message before request is made.</div>)
              }}
          </Get>
      </div>
  );
}

export default Wbnb;
