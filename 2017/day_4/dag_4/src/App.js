import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';

class App extends Component {
  render() {
    return (
      <div className="App">
        <header className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
          <h1 className="App-title">Welcome to React</h1>
        </header>

		
				

		
		test 
		
		scri
		
		filterFloat('421');
		
		
		
		
		</div>
		);
  }
}

class HelloMessage extends Component {
  render() {
    return <div>Hello <x-search>{this.props.name}</x-search>!</div>;
  }
}

var filterFloat = function(value) {
    if (/^(\-|\+)?([0-9]+(\.[0-9]+)?|Infinity)$/
      .test(value))
      return Number(value);
  return NaN;
}

export default App;
