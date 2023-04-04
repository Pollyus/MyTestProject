import React, { Component } from 'react';
import { Container, Typography } from "@mui/material";
import axios from 'axios';
import { render } from 'react-dom';
import { data } from 'jquery';
import { ResultData } from './ResultData.js';
import { Route } from 'react-router-dom';


export default function GetResultData(props)
  {
    const reports = props.reports;
    const xmlFile = reports.map((report)=> 
    <li key={report.jobId}>{report.xmlReport}</li>
    )
    const total = xmlFile.getElementsByTagName("total")
    return(
      <ul>{total}</ul>
    );
  }

export class ReportData extends Component {
  static displayName = ReportData.name;

  constructor(props) {
    super(props);
    this.state = { reports: [], loading: true };
  }

  componentDidMount() {
    this.populateWeatherData();
  }
   
  
  
  static renderreportsTable(reports) {

        return (
        <Container>
          <table className='table table-striped' aria-labelledby="tabelLabel">
            <thead>
              
              <Typography variant="h5" component="h5" ><th>Отчет в формате xml</th></Typography>
              
            </thead>
            <tbody>
              {reports.map(report =>
                <tr key={report.jobId}>
                  <td>{report.xmlReport}</td>
                </tr>
                
              )}
            </tbody>
            <Typography sx={{ fontWeight: 'bold' }} variant="h5" component="h5">Отчет в формате html</Typography>
            <Typography variant="h5">
              {reports.map(report =>
                <tr key={report.jobId}>       
                  <td>{report.htmlReport}</td>
                </tr>
              )}
            </Typography>
            <Typography>
              { <tr>
                <GetResultData reports = {reports}></GetResultData>
              </tr> }
            </Typography>
          </table>
           { <Component>
              <Route path='/result-data' component={ResultData}></Route>
              </Component>}
          <Container>
            
          </Container>
        </Container>
      );
          
    }
 

  render() {
  <div>
        <Typography>
        Test run details
            Total tests
            1

            Passed  : 1
            Failed  : 0
            Skipped : 0
            Pass percentage
            100 %

            Run duration
            1s 600ms


            All Results
            C:\Учеба\Практика\MyCalc\MyCalcTests\bin\Debug\net6.0\MyCalcTests.dll
            Informational messages
            [xUnit.net 00:00:00.00] xUnit.net VSTest Adapter v2.4.3+1b45f5407b (64-bit .NET 6.0.13)
            [xUnit.net 00:00:00.61] Discovering: MyCalcTests
            [xUnit.net 00:00:00.65] Discovered: MyCalcTests
            [xUnit.net 00:00:00.65] Starting: MyCalcTests
            [xUnit.net 00:00:00.71] Finished: MyCalcTests
        </Typography>
      </div>
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : ReportData.renderreportsTable(this.state.reports);
      
    return (
      <div>
       <Typography variant="h3" component="h2" >Результаты тестов</Typography>
        
        {contents}
      </div>
    );
  }

  async populateWeatherData() {
    const response = await fetch('api/report/get/all');
    const data = await response.json();
    
    this.setState({ reports: data, loading: false });
  }
}
