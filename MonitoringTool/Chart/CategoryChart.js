var monitoringTool = monitoringTool || {};

monitoringTool.categoryChart = function () {

    var init = function () {
        var originalLineDraw = Chart.controllers.line.prototype.draw;
        Chart.helpers.extend(Chart.controllers.line.prototype, {
            draw: function () {
                originalLineDraw.apply(this, arguments);

                var chart = this.chart;
                var ctx = chart.chart.ctx;

                if (ctx.textBaseline != "bottom") {

                    ctx.textAlign = "left";
                    ctx.textBaseline = "bottom";
                    ctx.font = "bold 11px Arial";
                    ctx.fontStyle = "bold";
                    ctx.lineWidth = 1;

                    var xaxis = chart.scales['x-axis-0'];
                    var yaxis = chart.scales['y-axis-0'];

                    var value = chart.config.meanValue.value
                    var linePositionY = yaxis.getPixelForValue(value);
                    ctx.fillStyle = chart.config.meanValue.color;
                    ctx.fillText(chart.config.meanValue.label + " (" + Math.floor(value) + ")", xaxis.left + 5, linePositionY);
                    ctx.strokeStyle = chart.config.meanValue.color;
                    ctx.beginPath();
                    ctx.moveTo(0, linePositionY);
                    ctx.lineTo(chart.chart.width, linePositionY);
                    ctx.stroke();
                }
            }
        });
    }();

    var renderChart = function (chartElement, data) {

        var labels = [];
        var statisticsValues = [];
        var maxValue = Number.MIN_VALUE;

        $(data.statistics).each(function (key, value) {
            labels.push(value.time.substring(0, 10));
            var currentValue = value.value;
            statisticsValues.push(currentValue);
            if (currentValue > maxValue) {
                maxValue = currentValue;
            }
        })

        var label = labels.length==0 ? "Not enough data to display usage statistics" : "Usage statistics";

        var plot = {
            labels: labels,           
            datasets: [
                {
                    label: label,
                    fill: false,
                    lineTension: 0.1,
                    backgroundColor: "rgba(75,192,192,0.4)",
                    borderColor: "rgba(41, 63, 197, 0.7)",
                    borderCapStyle: 'butt',
                    borderDash: [],
                    borderDashOffset: 0.0,
                    borderJoinStyle: 'miter',
                    pointBorderColor: "rgba(75,192,192,1)",
                    pointBackgroundColor: "#fff",
                    pointBorderWidth: 1,
                    pointHoverRadius: 5,
                    pointHoverBackgroundColor: "rgba(75,192,192,1)",
                    pointHoverBorderColor: "rgba(220,220,220,1)",
                    pointHoverBorderWidth: 2,
                    pointRadius: 3,
                    pointHitRadius: 10,
                    data: statisticsValues,
                    spanGaps: false,
                }
            ]
        };

        var options = {
            maintainAspectRatio: true,
            legend: {
                display: true
            },
            scales: {
                yAxes: [{
                    ticks: {
                        min: 0,
                        max: maxValue + 1
                    }
                }]
            }
        };

        var chartData = {
            type: 'line',
            data: plot,
            options: options,
            meanValue:
                {
                    label: "Mean Value",
                    value: data.meanValue,
                    color: "rgba(0, 0, 0, .8)"
                }
        };

        var chart = new Chart(chartElement, chartData);
    };

    return {
        renderChart: renderChart
    };
};