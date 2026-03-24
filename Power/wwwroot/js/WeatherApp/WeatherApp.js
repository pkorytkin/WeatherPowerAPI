const { createApp } = Vue;

createApp({
    data() {
        return {
            tab: 'current',
            dataIsLoaded: false,
            forecastData: null,
            loadInProgress: false
        }
    },
    mounted: function () {
        this.reloadInfo();
    },
    methods: {
        openCurrent() {
            this.tab = 'current';
        },
        openForecast() {
            this.tab = 'forecast';
        },
        reloadInfo() {
            if (this.loadInProgress) {
                return;
            }
            this.loadInProgress = true;
            $.ajax({
                url: "WeatherAPI/GetWeatherForecast",
                method: 'get',
                success: (data) => {
                    this.dataIsLoaded = true;
                    this.tab = this.tab == 'error' ? 'current' : this.tab;
                    this.forecastData = data;
                    this.loadInProgress = false;
                },
                error: (xhr, status, error) => {
                    this.tab = "error";
                    this.dataIsLoaded = false;
                    this.forecastData = null;
                    this.loadInProgress = false;
                }
            });
        },
    },
}).mount('#app');