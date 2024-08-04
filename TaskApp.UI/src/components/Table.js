import React, { useMemo } from "react";
import { useTable } from "react-table";


const Table = ({ data }) => {
  const columns = useMemo(
    () => [
        { Header: "Name", accessor: "name" },
        { Header: "StartTime", accessor: "startTime"},
        { Header: "EndTime", accessor: "endTime" },
        { Header: "ResponseData", accessor: "responseData" }
    ],
    []
  );

  const {
    getTableProps,
    getTableBodyProps,
    headerGroups,
    rows,
    prepareRow
  } = useTable({ columns, data });

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
              <tr {...row.getRowProps()}>
                {row.cells.map((cell) => (
                  <td {...cell.getCellProps()}>{cell.render("Cell")}</td>
                ))}
              </tr>
            );
          })}
        </tbody>
      </table>
    </div>
  );
};

export default Table;
