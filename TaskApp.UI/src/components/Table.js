import React, { useMemo, useState } from "react";
import { useTable } from "react-table";
import useModal from "./useModal";
import Modal from "./Modal";
import TaskService from "../services/TaskService";


const Table = ({ data }) => {
  const [cellData, setCellData] = useState({});
  const [blobId, setBlobId] = useState({});
  const columns = useMemo(
    () => [
        { Header: "Name", accessor: "name" },
        { Header: "StartTime", accessor: "startTime"},
        { Header: "EndTime", accessor: "endTime" },
        { Header: "BlobId", accessor: "blobId" }
    ],
    []
  );

  // const getLogList = () => {
  //       TaskService.task1()
  //           .then(response => {
  //               setLogs(response.data);
  //           })
  //           .catch(e => {
  //               console.log(e)
  //           });

  //   }
  const {isShowing, toggle} = useModal();

  const {
    getTableProps,
    getTableBodyProps,
    headerGroups,
    rows,
    prepareRow
  } = useTable({ columns, data });

  const handleRowClick = (data) => {
    
    if(data.column.Header === 'BlobId') {
      //setCellData(data.value)
      TaskService.task1BlobData(data.value).then(response => {
        setCellData(response.data.blobData)
        setBlobId(response.data.blobId)
        toggle();
        
                   })
                   .catch(e => {
                       console.log(e)
                   });
    }
   
  }

  return (
    <div className="table-container">
      <table {...getTableProps()} className="table table-striped table-bordered">
        <thead>
          {headerGroups.map((headerGroup) => (
            <tr {...headerGroup.getHeaderGroupProps()}>
              {headerGroup.headers.map((column) => (
                <th {...column.getHeaderProps()}>{column.render("Header")}</th>
              ))}
            </tr>
          ))}
        </thead>
        <tbody {...getTableBodyProps()}>
          {rows.map((row) => {
            prepareRow(row);
            return (
              <tr {...row.getRowProps()} >
                {row.cells.map((cell) => (
                  
                   <td className={cell.column.Header === 'BlobId'? 'r-link': ''} onClick={()=> handleRowClick(cell )} {...cell.getCellProps()}>{cell.render("Cell")}</td>
                 
                ))}
              </tr>
            );
          })}
        </tbody>
      </table>

      <Modal
        data={cellData}
        isShowing={isShowing}
        hide={toggle}
        blobId={blobId}
      />
    </div>
  );
};

export default Table;
