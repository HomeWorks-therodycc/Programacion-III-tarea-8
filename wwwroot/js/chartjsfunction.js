function vacunasChart(labels, data) {
    var ctx = document.getElementById('myChart').getContext('2d');
    var myChart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: labels,
            datasets: [{
                label: '# de vacunados',
                data: data,
                backgroundColor: [
                    'rgba(0, 78, 124, 0.322)',
                    'rgba(0, 78, 124, 0.322)',
                    'rgba(0, 78, 124, 0.322)',
                    'rgba(0, 78, 124, 0.322)',
                    'rgba(0, 78, 124, 0.322)',
                    ' rgba(0, 78, 124, 0.904)'
                ],
                borderColor: [
                    ' rgba(0, 78, 124, 0.904)',
                    ' rgba(0, 78, 124, 0.904)',
                    ' rgba(0, 78, 124, 0.904)',
                    ' rgba(0, 78, 124, 0.904)',
                    ' rgba(0, 78, 124, 0.904)',
                    ' rgba(0, 78, 124, 0.904)'
                ],
                borderWidth: 1
            }]
        },
        options: {
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: true,
                        callback: function(value) {if (value % 1 === 0) {return value;}}
                    }
                }]
            },
            responsive: false
        }
    });
    return "a";
}