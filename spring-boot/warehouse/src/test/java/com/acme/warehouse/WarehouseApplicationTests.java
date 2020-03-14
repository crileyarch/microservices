package com.acme.warehouse;

import com.acme.warehouse.model.Warehouse;
import org.junit.jupiter.api.Test;
import org.springframework.boot.test.context.SpringBootTest;

import static org.junit.jupiter.api.Assertions.assertNotNull;
import static org.junit.jupiter.api.Assertions.assertTrue;

@SpringBootTest
class WarehouseApplicationTests {

	@Test
	void contextLoads() {
	}

	@Test
	public void createWarehouse()
	{

		Warehouse warehouse = new Warehouse();

		warehouse.setWarehouseId("123");
		warehouse.setLocation("Fall River, MA, USA");
		assertNotNull(warehouse);
		assertTrue("Fall River, MA, USA".equals(warehouse.getLocation()));

	}


}
