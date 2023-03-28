import React, { Component } from 'react';
import { Container, Typography } from "@mui/material";
import { DataGrid } from '@mui/x-data-grid';

const columns = [
  { field: 'id', headerName: 'PipelineId', width: 130 },
  { field: 'firstName', headerName: 'JobId', width: 130 },
  { field: 'lastName', headerName: 'Passed', width: 130 },
  { field: 'Failed', headerName: 'Failed', width: 130 },
  { field: 'Total', headerName: 'Total', width: 130 },
  { field: 'Skipped', headerName: 'Skipped', width: 130 },
 
  {
    field: 'fullName',
    headerName: 'Full path to test',
    description: 'This column has a value getter and is not sortable.',
    sortable: false,
    width: 160,
    
  },
];

const rows = [
  { id: 1, lastName: '1', firstName: '20', Failed: '0', Total: '1', Skipped: '0',
    fullName: '"C:\Учеба\Практика\MyCalc\MyCalcTests\bin\Debug\net6.0\MyCalcTests.dll" ',

  },
  
];

export default function DataTable() {
  return (
    <div style={{ height: 400, width: '100%' }}>
      <DataGrid
        rows={rows}
        columns={columns}
        presultSize={5}
        rowsPerPresultOptions={[5]}
       
      />
    </div>
  );
}


export class ResultData extends Component {
  static displayName = ResultData.name;

  constructor(props) {
    super(props);
    this.state = { reports: [], loading: true };
  }
  render(){  
    return(
      <div>
        <h1 id="tabelLabel" >Результаты тестов</h1>
        <DataTable></DataTable>

      </div>
    );
  
  }

}