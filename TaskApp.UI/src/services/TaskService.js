import http from "../http-common";

const task1 = (fromDate,toDate) =>{
    if(fromDate!="" && fromDate!= undefined)
        return http.get("/task1?fromDate="+fromDate+"&toDate="+toDate);
    else
        return http.get("/task1");
};

const task1BlobData =(guid) =>{
    return http.get("/task1-blobdata?guid="+guid)
};

const task2= (date)=>{
    if(date!="" && date!= undefined)
        return http.get("/task2?datetime="+date);
    else
        return http.get("/task2");
};

const TaskService = {
    task1,
    task2,
    task1BlobData
};

export default TaskService;