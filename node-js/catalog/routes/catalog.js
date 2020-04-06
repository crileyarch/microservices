const express = require('express');
const router = express.Router();
router.use(express.json());

const catalogItems = {sku: '1', description: 'hammer', warehouseId: '44155231-44'}

router.get('/', (req,res) => {
    console.log('In catalog GET');
    res.status(200).send(catalogItems);
})

module.exports = router;