//var initialDate = new Date();
//initialDate.setHours(initialDate.getHours() - 3);
//[initialDate.getTime(), 0]

const onChartLoad = function () {
    const chart = this,
        series = chart.series[0];

    setInterval(async function () {

        $.ajax({
            type: 'GET',
            url: '/Dashboard/GetTemperatura'
        }).done(function (data) {

            const chartData = data.contextResponses[0].contextElement.attributes[0].values[0];
            let utc = new Date(chartData.recvTime);
            utc.setHours(utc.getHours() - 3);

            let date = utc.getTime();
            let temp = chartData.attrValue;

            series.addPoint([date, temp]);
        });

    }, 1000);
};

$(document).ready(function () {

    Highcharts.chart('chart-realtime', {
        chart: {
            zooming: {
                type: 'x'
            },
            backgroundColor: '#1f2029',
            style: {
                color: "#ffeba7"
            },
            events: {
                load: onChartLoad
            }
        },
        title: {
            text: 'Temperatura x Tempo',
            align: 'left',
            style: {
                color: "#ffeba7"
            }
        },
        subtitle: {
            text: document.ontouchstart === undefined ?
                'Clique e arraste para selecionar um período de tempo' :
                'Pinch the chart to zoom in',
            align: 'left',
            style: {
                color: "#ffeba7"
            }
        },
        xAxis: {
            type: 'datetime',
            labels: {
                style: {
                    color: '#ffeba7',
                }
            },
        },
        yAxis: {
            title: {
                text: 'Temperatura (ºC)',
                style: {
                    color: "#ffeba7"
                }
            },
            labels: {
                style: {
                    color: '#ffeba7',
                }
            },
            gridLineColor: '#333333'
        },
        legend: {
            enabled: false
        },
        tooltip: {
            shared: true,
            valueSuffix: '°C'
        },
        plotOptions: {
            area: {
                fillColor: {
                    linearGradient: {
                        x1: 0,
                        y1: 0,
                        x2: 0,
                        y2: 1
                    },
                    stops: [
                        [0, Highcharts.getOptions().colors[0]],
                        [
                            1,
                            Highcharts.color(Highcharts.getOptions().colors[0])
                                .setOpacity(0).get('rgba')
                        ]
                    ]
                },
                marker: {
                    radius: 2
                },
                lineWidth: 1,
                states: {
                    hover: {
                        lineWidth: 1
                    }
                },
                threshold: null
            }
        },

        series: [{
            type: 'area',
            name: 'Temperatura',
            data: []
        }],
        credits: {
            enabled: false
        }
    });

    Highcharts.setOptions({
        lang: {
            months: ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
            shortMonths: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez'],
            weekdays: ['Domingo', 'Segunda', 'Terça', 'Quarta', 'Quinta', 'Sexta', 'Sábado'],
            loading: ['Atualizando o gráfico...aguarde']
        }
    });

});

var dashboard = function () {

    var init = function () {

    }

    return {
        init: init,
    }
}();