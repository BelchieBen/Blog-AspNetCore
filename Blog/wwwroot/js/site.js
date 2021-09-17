function Linechart() {
    const labels = [
        'January',
        'February',
        'March',
        'April',
        'May',
        'June',
    ];
    const data = {
        labels: labels,
        datasets: [{
            label: 'My First dataset',
            backgroundColor: 'rgb(255, 99, 132)',
            borderColor: 'rgb(255, 99, 132)',
            data: [0, 10, 5, 2, 20, 30, 45],
        }]
    };
    const config = {
        type: 'line',
        data: data,
        options: {}
    };
    var myChart = new Chart(
        document.getElementById('myChart'),
        config
    );
}

function PolarArea() {
    const DATA_COUNT = 5;
    const NUMBER_CFG = { count: DATA_COUNT, min: 0, max: 100 };
    const labels = ['Red', 'Orange', 'Yellow', 'Green', 'Blue'];
    const data = {
        labels: labels,
        datasets: [
            {
                label: 'Dataset 1',
                data: Samples.utils.numbers(NUMBER_CFG),
                backgroundColor: [
                    Samples.utils.transparentize(255, 99, 132, 0.5),
                    Samples.utils.transparentize(255, 159, 64, 0.5),
                    Samples.utils.transparentize(255, 205, 86, 0.5),
                    Samples.utils.transparentize(75, 192, 192, 0.5),
                    Samples.utils.transparentize(54, 162, 235, 0.5),
                ]
            }
        ]
    };
    const config = {
        type: 'polarArea',
        data: data,
        options: {
            responsive: true,
            plugins: {
                legend: {
                    position: 'top',
                },
                title: {
                    display: true,
                    text: 'Chart.js Polar Area Chart'
                }
            }
        },
    };
    var polararea = new Chart(document.getElementById('polararea'), config, data);
}
