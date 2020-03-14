const express = require('express');
const router = express.Router();
router.use(express.json());

const catalogItems = [
    {sku: 1, description: 'hammer', warehouseId: '1'},
    {sku: 2, description: 'screw driver', warehouseId: '1'},
    {sku: 3, description: 'wrench', warehouseId: '2'}
]

router.get('/', (req,res) => {
    console.log('In catalog GET');
    res.status(200).send(catalogItems);
})

module.exports = router;