CREATE TABLE IF NOT EXISTS users (
	id BIGSERIAL NOT NULL,
	user_name VARCHAR(60),
	pass_hash VARCHAR(255),
	email VARCHAR(100),
	registered_on_date timestamp,
	first_name VARCHAR(255),
	last_name VARCHAR(255),
	middle_name VARCHAR(255),
	PRIMARY KEY(id)
);

CREATE TABLE IF NOT EXISTS user_addresses (
	id BIGSERIAL NOT NULL,
	street_road VARCHAR(100),
	city_fkid INT,
	zip_code VARCHAR(15),
	country_fkid INT,
	FOREIGN KEY (city_fkid) REFERENCES cities(id),
	PRIMARY KEY(id)
);

CREATE TABLE IF NOT EXISTS cities (
	id BIGSERIAL NOT NULL,
	city_name VARCHAR(255),
	PRIMARY KEY(id)
);

CREATE TABLE IF NOT EXISTS countries (
	id BIGSERIAL NOT NULL,
	country_name VARCHAR(255),
	PRIMARY KEY(id)
);

CREATE TABLE IF NOT EXISTS product_types (
	id BIGSERIAL NOT NULL,
	type VARCHAR(60),
	PRIMARY KEY(id)
);
