import logo from './logo.svg';
import './App.css';
import { XYPlot, VerticalBarSeries } from 'react-vis';
import { Get,  } from 'react-axios'

function App() {
  var data = [];
  return (
      <div>
          <Get url="http://localhost:8222/api/event/Transfer?NumberBlocks=10">
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
                              {response.data.forEach((e, i) => data.push({ x: i, y: e.wad }))}
                              <div className="App">
                                  <XYPlot stackBy="y" height={300} width={799}>
                                      <VerticalBarSeries data={data} />
                                  </XYPlot>
                              </div>
                             
                          </div>)
                  }
                  return (<div>Default message before request is made.</div>)
              }}
          </Get>
      </div>
  );
}

export default App;
