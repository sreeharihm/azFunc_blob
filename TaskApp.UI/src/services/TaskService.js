import http from "../http-common";

const task1 = (fromDate,toDate) =>{
    if(fromDate!="" && fromDate!= undefined)
        return http.get("/Task1?fromDate="+fromDate+"&toDate="+toDate);
    else
        return http.get("/Task1");
};

const task2= (date)=>{
    if(date!="" && date!= undefined)
        return http.get("/Task2?datetime="+date);
    else
        return http.get("/Task2");
};

const TaskService = {
    task1,
    task2
};

export default TaskService;