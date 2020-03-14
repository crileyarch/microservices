//express dependencies

const express = require('express');
const app = express();

//route dependencies

const catalogRouter = require('./routes/catalog.js');
app.use('/catalog', catalogRouter);

//configuration output

//console.log('Application Name: ' + config.get('name'));
//console.log('Database Server Name: ' + config.get('database.host'));



//environment variable for port
const port = process.env.PORT || 5000;

app.listen(port, () => console.log(`Listening on port ${port}....`));