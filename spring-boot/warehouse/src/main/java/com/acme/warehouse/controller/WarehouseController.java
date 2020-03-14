package com.acme.warehouse.controller;


import com.acme.warehouse.model.Warehouse;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.web.bind.annotation.*;

@RestController
public class WarehouseController {

    private final Logger logger = LoggerFactory.getLogger(this.getClass());

    @RequestMapping(value = "/warehouses/{warehouseId}", method = RequestMethod.GET)
    public Warehouse getWarehouses(@PathVariable("warehouseId") int warehouseId){

        logger.info("In getWarehouses");
        Warehouse warehouse = new Warehouse();
        warehouse.setLocation("Secacaus, NJ, USA");
        warehouse.setWarehouseId("44155231-44");
        return warehouse;
    }

    @RequestMapping(value = "/warehouses", method = RequestMethod.POST)
    public void createWarehouses(@RequestBody Warehouse warehouseInstance){

        logger.info("In createWarehouses");
        logger.info("Warehouse id is: " + warehouseInstance.getWarehouseId());
        logger.info("Warehouse location is: " + warehouseInstance.getLocation());
    }

}
