// Select DOM elements to work with
const weatherForecastDiv = document.getElementById("weatherForecast-div");

async function weatherForecast() {
    callWeatherForecast("/WeatherForecast", updateUI);
}

function callWeatherForecast(endpoint, callback) {
    const headers = new Headers();
    headers.append("Access-Control-Allow-Origin", "*");

    const options = {
        method: "GET",
        headers: headers
    };

    console.log('request made to ' + endpoint + ' at: ' + new Date().toString());

    fetch(endpoint, options)
        .then(response => {
            var result = new Object();
            if (response.status == 401) {
                result.data = null;
                result.error = "Unauthorized";
            } else {
                return response.json();
            }
            return result;
        })
        .then(result => callback(result))
        .catch(error => console.log(error));
}

function updateUI(result) {
    if (result.error != null) {
        weatherForecastDiv.innerHTML = ''
        const error = document.createElement('p');
        error.innerHTML = "<strong>error: </strong>" + result.error;
        weatherForecastDiv.appendChild(error);
        return;
    }

    weatherForecastDiv.innerHTML = ''
    const date = document.createElement('p');
    date.innerHTML = "<strong>date: </strong>" + result[0].date;
    const tempC = document.createElement('p');
    tempC.innerHTML = "<strong>tempC: </strong>" + result[0].temperatureC;
    const tempF = document.createElement('p');
    tempF.innerHTML = "<strong>tempF: </strong>" + result[0].temperatureF;
    const summary = document.createElement('p');
    summary.innerHTML = "<strong>summary: </strong>" + result[0].summary;
    weatherForecastDiv.appendChild(date);
    weatherForecastDiv.appendChild(tempC);
    weatherForecastDiv.appendChild(tempF);
    weatherForecastDiv.appendChild(summary);
}
