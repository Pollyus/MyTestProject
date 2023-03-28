import { Typography, Container } from '@mui/material';
import React, { PureComponent } from 'react';
import { AreaChart, Area, XAxis, YAxis, CartesianGrid, Tooltip, ResponsiveContainer } from 'recharts';

const data = [
  {
    name: 'Тест 1',
    uv: 4.36 ,
   
  },
  {
    name: 'Тест 2',
    uv: 9.384,

  },
  {
    name: 'Тест 3',
    uv: 33.253,
   
  },
  {
    name: 'Тест 4',
    uv: 4.875,
 
  },
  {
    name: 'Тест 5',
    uv: 1.543,
   
  },
  {
    name: 'Тест 6',
    uv: 4.192,
   
  },
  {
    name: 'Тест 7',
    uv: 2.195,
    
  },
];

export default class Chart extends PureComponent {
  static demoUrl = 'https://codesandbox.io/s/simple-area-chart-4ujxw';
  static displayName = Chart.name;
  render() {
    return (
      <Container>
      <Typography variant="h3" component="h2">График</Typography>
      <Typography>График зависимости времени от попытки выполнения теста</Typography>
      <ResponsiveContainer width="100%" aspect={3}>
        <AreaChart
          width={500}
          height={400}
          data={data}
          margin={{
            top: 10,
            right: 30,
            left: 0,
            bottom: 0,
          }}
        >
          <CartesianGrid strokeDasharray="3 3" />
          <XAxis dataKey="name" />
          <YAxis />
          <Tooltip />
          <Area type="monotone" dataKey="uv" stroke="#8884d8" fill="#8884d8" />
        </AreaChart>
      </ResponsiveContainer>
      </Container>
    );
  }
}
