const express = require('express');
const app = express();
const cors = require('cors');
const port = 3000;

// Run API using following command: node app.js

app.use(express.json());
app.use(express.urlencoded({ extended: true }));
app.use(cors());

app.listen(port, () => {
    console.log(`Server is running on port ${port}`);
});

jsonArray = require('./stocks.json');
jsonArray = jsonArray['stocks'];
const array = [];
jsonArray.forEach(element => {
    array.push(element)
});

app.get('/', (req, res) => {
    res.send('Node.js server is running')
});

app.get('/stocks', (req, res) => {
    res.send(array)
});

app.get('/stocks/:symbol', (req, res) => {
    const symbol = req.params.symbol;
    const index = array.findIndex((stock) => stock.symbol === symbol);
    if (index !== -1) {
        res.send(array[index]);
    } else {
        res.send('Stock not found');
    }
});

app.post('/add/stock', (req, res) => {
    const name = req.body.name;
    const symbol = req.body.symbol;
    const price = req.body.price;

    const newStock = {
        name: name,
        symbol: symbol,
        price: price
    }

    array.push(newStock);
    res.send(array);
});

app.delete('/delete/stock/:symbol', (req, res) => {
    // Get the symbol from the request parameters.
    const symbol = req.params.symbol;

    // Find the index of the stock in the array based on its symbol.
    const index = array.findIndex((stock) => stock.symbol === symbol);

    // If the stock exists in the array, remove it from the array.
    if (index !== -1) {
        array.splice(index, 1);
    }

    // Send the modified array as the response.
    res.send(array);
});

app.put('/update/stock/:symbol', (req, res) => {
    // The request parameter 'symbol' is assigned to a constant 'symbol'.
    const symbol = req.params.symbol;

    // Gets the index of the stock in the array based on its symbol.
    const index = array.findIndex((stock) => stock.symbol === symbol);

    // If the stock exists in the array, update its name, symbol and price.
    if (index !== -1) {
        array[index].name = req.body.name;
        array[index].symbol = req.body.symbol;
        array[index].price = req.body.price;
    }

    // Send the modified array as the response.
    res.send(array);
});
