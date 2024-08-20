import React, { useState, useEffect, useMemo } from "react";
import { useTable } from "react-table";
import TaskService from "../services/TaskService";
import Table from "./Table";
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";

const LogList = () => {
    const [logs, setLogs] = useState([]);
    const [fromDate, setFromDate] = useState(new Date());
    const [toDate, setToDate] = useState(new Date());

    useEffect(() => {
        getLogList();
    }, []);

    const findByDate = () => {
        TaskService.task1(fromDate.toLocaleDateString(), toDate.toLocaleDateString())
            .then(response => {
                setLogs(response.data);
            }).catch(e => {
                console.log(e)
            });
    }
    const getLogList = () => {
        TaskService.task1()
            .then(response => {
                setLogs(response.data);
            })
            .catch(e => {
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

            <div >

                <div className="form-container">
                    <div className="date-picker-c">
                        <label className="form-label">From Date:</label>
                        <div className="p-l-8">
                            <DatePicker selected={fromDate} onChange={(fromDate) => setFromDate(fromDate)} />
                        </div>

                    </div>
                    <div className="date-picker-c">
                        <label className="form-label">To Date:</label>
                        <div className="p-l-8">
                            <DatePicker maxDate={toDate} selected={toDate} onChange={(toDate) => setToDate(toDate)}  />
                        </div>
                    </div>
                    <div className="input-group-append p-l-8">
                        <button  type="button" onClick={findByDate}>Search</button>
                    </div>
                </div>
            </div>
            <div className="col-md-12 list table-container">
                <Table data={logs} />
            </div>

        </div>
    );
};

export default LogList;
