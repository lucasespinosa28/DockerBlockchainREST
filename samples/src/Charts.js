import React, { Component } from 'react';
import './App.css';
import '../node_modules/react-vis/dist/style.css';
import { XYPlot, VerticalBarSeries } from 'react-vis';
import { AxiosProvider, Request, Get, Delete, Head, Post, Put, Patch, withAxios } from 'react-axios'

class Charts extends Component {
    render() {
        <Get url="http://localhost:8222/api/event/Transfer?NumberBlocks=10">
            {(error, response, isLoading, makeRequest, axios) => {
                if (error) {
                    return (<div>Something bad happened: {error.message} <button onClick={() => makeRequest({ params: { reload: true } })}>Retry</button></div>)
                }
                else if (isLoading) {
                    return (<div>Loading...</div>)
                }
                else if (response !== null) {
                    return (<div>{response.data}</div>)

                }
                return (<div>Default message before request is made.</div>)
            }}
        </Get>
        const data = [
            { x: 0, y: 5 },
            { x: 0, y: 3 },
            { x: 1, y: 5 },

        ];
        return (
            <div className="App">
                <XYPlot height={300} width={300}>
                    <VerticalBarSeries  data={data} />
                </XYPlot>
            </div>
        );
    }
}

export default Charts;