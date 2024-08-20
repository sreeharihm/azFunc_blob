import { Bar } from "react-chartjs-2";
import Chart from 'chart.js/auto';

const BarGraph = ({apiData}) =>{
    return(
        <div style={{ maxWidth: "650px" }}>
                <Bar
                    data={{
                        // Name of the variables on x-axies for each bar
                        labels: apiData.map((item) => item.city),
                        datasets: [
                            {
                                // Label for bars
                                label: "Min-Temp",
                                // Data or value of your each variable
                                data:  apiData.map((item) => item.minTemp),
                                // Color of each bar
                                backgroundColor: 
                                    [ "aqua"],
                                // Border color of each bar
                                borderColor: ["aqua"],
                                borderWidth: 0.5,
                            },{
                                // Label for bars
                                label: "Max-Temp",
                                // Data or value of your each variable
                                data: apiData.map((item) => item.maxTemp),
                                // Color of each bar
                                backgroundColor: 
                                    ["green"],
                                // Border color of each bar
                                borderColor: ["green"],
                                borderWidth: 0.5,
                            },
                        ],
                    }}
                    // Height of graph
                    height={400}
                    options={{
                        maintainAspectRatio: false,
                        scales: {
                            yAxes: [
                                {
                                    ticks: {
                                  // The y-axis value will start from zero
                                        beginAtZero: true,
                                    },
                                },
                            ],
                        },
                        legend: {
                            labels: {
                                fontSize: 15,
                            },
                        },
                    }}
                />
            </div>

    );
};

export default BarGraph;