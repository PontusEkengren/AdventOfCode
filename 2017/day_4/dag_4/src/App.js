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
<h1>My First Web Page</h1>
<p>My First Paragraph</p>
		<p id="demo"></p>

<script>
document.getElementById("demo").innerHTML = 5 + 6;
</script>
      </div>
    );
  }
}

export default App;
