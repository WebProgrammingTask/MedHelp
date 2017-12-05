import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import { ApiService } from '../../models/ApiService'


interface WeatherForecast {
    dateFormatted: string;
    temperatureC: number;
    temperatureF: number;
    summary: string;
}

@Component
export default class FetchDataComponent extends Vue {
    forecasts: WeatherForecast[] = [];

    mounted() {
        ApiService.get("SampleData/WeatherForecasts",
            {
                headers: {
                    Authorization: 'Bearer ' + localStorage.getItem('access_token')
                }
            })
            .then(response => {
                this.forecasts = response.data
            })
            .catch(e => {
                alert(e)
            });
    }
}
