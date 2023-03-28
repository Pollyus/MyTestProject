import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
//import  { Chart } from './components/Chart';
import { ReportData } from './components/ReportData';
import { ResultData } from './components/ResultData';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/report-data' component={ReportData} />
        <Route path='/result-data' component={ResultData} />
        
        
      </Layout>
    );
  }
}
