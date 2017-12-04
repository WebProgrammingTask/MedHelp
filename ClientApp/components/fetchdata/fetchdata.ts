import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import axios from 'axios';


interface WeatherForecast {
    dateFormatted: string;
    temperatureC: number;
    temperatureF: number;
    summary: string;
}

@Component
export default class FetchDataComponent extends Vue {
    forecasts: WeatherForecast[] = [];
     HTTP = axios.create({
        baseURL: 'api/SampleData/WeatherForecasts',
        
      })
    mounted() {
        axios.get("api/SampleData/WeatherForecasts",
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
            })
           
        // fetch('api/SampleData/WeatherForecasts')
        
    }
}
