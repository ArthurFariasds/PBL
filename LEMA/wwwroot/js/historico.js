var averages = [];
var ranges = [];
var $chart;

$(document).ready(function () {
    historico.init();
});

var historico = function () {

    var init = function () {
        montaMediaERange($historicoViewModel);
        montarGrafico(averages, ranges);
    }

    var montaMediaERange = function (data) {

        for (var i = 0; i < data.mediasDasTemperaturas.length; i++) {

            let temperatura = data.mediasDasTemperaturas[i];

            let dataObj = new Date(temperatura.dataLeitura);
            let ano = dataObj.getFullYear();
            let mes = dataObj.getMonth();
            let dia = dataObj.getDate();
            let dataUTC = Date.UTC(ano, mes, dia);

            ranges.push([
                Date.UTC(ano, mes, dia),
                parseFloat(temperatura.menorTemperatura.toFixed(2)),
                parseFloat(temperatura.maiorTemperatura.toFixed(2))
            ]);

            averages.push([
                Date.UTC(ano, mes, dia),
                parseFloat(temperatura.mediaTemperatura.toFixed(2))
            ]);
        }
    }

    //var pesquisar = function () {

    //    $.ajax({
    //        type: 'POST',
    //        url: '/Dashboard/GetHistorico',
    //        data: {
    //            'filtro': {
    //                'TemperaturaInicial': $('#TemperaturaInicial').val(),
    //                'TemperaturaFinal': $('#TemperaturaFinal').val(),
    //                'DataInicio': $('#DataInicio').val(),
    //                'DataFim': $('#DataFim').val(),
    //            }
    //        }
    //    }).done(function (data) {
    //        montaMediaERange(data);
    //        $chart.series[0].setData(averages);
    //        $chart.series[1].setData(ranges);
    //    });
    //}

    var montarGrafico = function (averages, ranges) {

        $chart = Highcharts.chart('chart-mediaTemperaturas', {
            chart: {
                backgroundColor: '#1f2029',
                style: {
                    color: "#ffeba7"
                },
                width: 800,
                height: 400
            },
            title: {
                text: 'Média das temperaturas',
                align: 'center',
                style: {
                    color: "#ffeba7"
                }
            },
            xAxis: {
                type: 'datetime',
                dateTimeLabelFormats: {
                    month: '%b'
                },
                labels: {
                    formatter: function () {
                        return Highcharts.dateFormat('%d %b', this.value).replace('Jan', 'Jan').replace('Feb', 'Fev').replace('Mar', 'Mar').replace('Apr', 'Abr').replace('May', 'Mai').replace('Jun', 'Jun').replace('Jul', 'Jul').replace('Aug', 'Ago').replace('Sep', 'Set').replace('Oct', 'Out').replace('Nov', 'Nov').replace('Dec', 'Dez');
                    },
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
                crosshairs: true,
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
                name: 'Média',
                data: averages,
                zIndex: 1,
                marker: {
                    fillColor: 'lightblue',
                    lineWidth: 2,
                    lineColor: Highcharts.getOptions().colors[0]
                }
            }, {
                name: 'Range',
                data: ranges,
                type: 'arearange',
                lineWidth: 0,
                linkedTo: ':previous',
                color: Highcharts.getOptions().colors[0],
                fillOpacity: 0.3,
                zIndex: 0,
                marker: {
                    enabled: false
                },
                zones: [{
                    value: 40, // De 20 a 40
                    color: '#54B4FC' // Cor média
                }, {
                    color: '#FF0000' // Acima de 40
                }]

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
    }

    return {
        init: init,
    }
}();