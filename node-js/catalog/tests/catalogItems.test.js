const catalogItems = require('../models/catalogItems');

describe('catalogItems', () => {
 
    console.log('catalog items = ' + catalogItems.sku);
    //Get a catalogItem and check for hammer
    it('should create a simple catalogItem', () => {
        const result = catalogItems;
        expect(result.description).toBe(undefined);
    });

});