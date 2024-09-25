const express = require("express");
const path = require("path");
const bodyParser = require("body-parser");
const axios = require("axios");

const app = express();

app.use(bodyParser.json()); // Para analizar cuerpos JSON
app.use(bodyParser.urlencoded({ extended: true })); 
app.set('view engine', 'ejs');
app.set('views', path.join(__dirname, 'views'));


const API_URL = "http://api:8080";
const port = 3000;

app.get('/', async (req, res) => {
    try{
        const response = await axios.get(`${API_URL}/user`);
        const usuario = response.data;
        console.log(usuario);
        res.render('user', usuario)
    }catch(error){
        res.json(error)
    }
})


app.listen(port, () => {
    console.log("EL servidor esta siendo ejecutado en el puerto http://localhost:3000")
} )