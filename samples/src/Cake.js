import logo from './logo.svg';
import './App.css';
import { AxiosProvider, Request, Get, Delete, Head, Post, Put, Patch, withAxios } from 'react-axios'

function Cake() {
  return (
      <div>
          <Get url="http://localhost:8330/api/event/Swap?NumberBlocks=5">
              {(error, response, isLoading, makeRequest, axios) => {
                  if (error) {
                      return (<div>Something bad happened: {error.message} <button onClick={() => makeRequest({ params: { reload: true } })}>Retry</button></div>)
                  }
                  else if (isLoading) {
                      return (<div>Loading...</div>)
                  }
                  else if (response !== null) {
                      return (
                          <div>
                              <table class="flex-grow font-semibold">
                                  <thead className="bg-green-200 text-green-600 shadow-md">
                                  <tr>
                                    <th>BlockNumber</th>
                                    <th>TransactionHash</th>
                                    <th>amountIn</th>
                                    <th>amountOut</th>
                                   </tr>
                                  </thead>
                                  <tbody className="bg-emerald-200">
                                      {response.data.map((e, i) => 
                                          <tr>
                                              <td className="border-b-2 border-green-600 shadow-inner">{e.BlockNumber}</td>
                                              <td className="border-b-2 border-green-600 shadow-inner">{e.TransactionHash.slice(18)}...</td>
                                              <td className="border-b-2 border-green-600 shadow-inner">{(e.amount0In + e.amount1In) / 1e18}</td>
                                              <td className="border-b-2 border-green-600 shadow-inner">{(e.amount0Out + e.amount1Out) / 1e18}</td>
                                          </tr>)}
                                  </tbody>
                              </table>
                          </div>
                      )
                  }
                  return (<div>Default message before request is made.</div>)
              }}
          </Get>
      </div>
  );
}
//<table class="table-auto">
//    <thead>
//        <tr>
//            <th>Title</th>
//            <th>Author</th>
//            <th>Views</th>
//        </tr>
//    </thead>
//    <tbody>
//        <tr>
//            <td>Intro to CSS</td>
//            <td>Adam</td>
//            <td>858</td>
//        </tr>
//        <tr class="bg-emerald-200">
//            <td>A Long and Winding Tour of the History of UI Frameworks and Tools and the Impact on Design</td>
//            <td>Adam</td>
//            <td>112</td>
//        </tr>
//        <tr>
//            <td>Intro to JavaScript</td>
//            <td>Chris</td>
//            <td>1,280</td>
//        </tr>
//    </tbody>
//</table>
export default Cake;
