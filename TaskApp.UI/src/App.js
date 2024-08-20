import logo from './logo.svg';
import "bootstrap/dist/css/bootstrap.min.css";
import { Routes,Route,Link } from 'react-router-dom';
import LogList from "./components/LogList";
import WeatherData from "./components/WeatherData";

function App() {
  return (
    <div>
      <nav className="navbar navbar-expand navbar-dark bg-dark">
        <a href="/log-list" className="navbar-brand p-l-8">
          Task UI
        </a>
        <div className="navbar-nav mr-auto">
          <li className="nav-item">
              <Link to={"/log-list"} className="nav-link">     
                Log List
              </Link>
          </li>
          <li className="nav-item">
              <Link to={"/weather-data"} className="nav-link">
                Weather Data
              </Link>
          </li>
        </div>
      </nav>
      <div className="container mt-3">
        <Routes>
            <Route path="/" element= {<LogList/>} />
            <Route path="/log-list" element= {<LogList/>} />
            <Route path="/weather-data" element= {<WeatherData/>} />
        </Routes>
      </div>
    </div>
  );
}

export default App;
