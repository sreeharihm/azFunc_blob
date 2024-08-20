import React, {useState, useEffect} from "react";
import TaskService from "../services/TaskService";
import BarGraph from "./BarGraph";
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";



const WeatherData = () =>{
    const [data, setData] = useState([]);
    const [date, setDate] = useState(new Date());

    useEffect(() =>{
        getWeatherData();
    }, []);


    const findByDate = () => {
        TaskService.task2(date.toLocaleDateString())
        .then(response =>{
            setData(response.data);
        }).catch(e =>{
            console.log(e)
        });
    }

    const getWeatherData = () =>{
        TaskService.task2()
        .then(response => {
            setData(response.data);
        })
        .catch(e =>{
            console.log(e)
        });
    }
    return (
        <div className="list row">
            <div className="col-md-6 ">
                <h4>Weather Data</h4>
            </div>
            <div className="col-md-8">
                <div className="input-group mb-3">
                <DatePicker maxDate={date} selected={date}  onChange={(date) => setDate(date)} />
                    <div className="input-group-append p-l-8">
                        <button  type="button" onClick={findByDate}>Search</button>
                    </div>
                </div>
            </div>
            <div className="col-md-12 list">
                <BarGraph apiData={data}></BarGraph>
            </div>
        </div>
    );
};

export default WeatherData;
