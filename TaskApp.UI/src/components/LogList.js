import React, {useState, useEffect, useMemo} from "react";
import { useTable } from "react-table";
import TaskService from "../services/TaskService";
import Table from "./Table";
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";

const LogList = () =>{
    const [logs, setLogs] = useState([]);
    const [fromDate, setFromDate] = useState(new Date());
    const [toDate, setToDate] = useState(new Date());
    
    useEffect(() =>{
        getLogList();
    }, []);

    const findByDate = () => {
        TaskService.task1(fromDate.toLocaleDateString(),toDate.toLocaleDateString())
        .then(response =>{
            setLogs(response.data);
        }).catch(e =>{
            console.log(e)
        });
    }
    const getLogList = () =>{
        TaskService.task1()
        .then(response => {
            setLogs(response.data);
        })
        .catch(e =>{
            console.log(e)
        });

    }

    return (
        <div className="list row">
            
            <div className="col-md-6">
                <div>
                    <h4>Log List</h4>
                </div>
            </div>

            <div className="col-md-8">
                
                <div className="input-group mb-3">
                <label>From Date:</label>
                    <DatePicker selected={fromDate}  onChange={(fromDate) => setFromDate(fromDate)} />
                    <label>To Date:</label>
                    <DatePicker selected={toDate}  onChange={(toDate) => setToDate(toDate)} />
                    <div className="input-group-append">
                        <button className="btn btn-outline-secondary" type="button" onClick={findByDate}>Search</button>
                    </div>
                </div>
            </div>
            <div className="col-md-12 list">
                <Table data={logs} />
            </div>

        </div>
    );
};

export default LogList;
