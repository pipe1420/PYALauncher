-- DROP SCHEMA pya_apps;

CREATE SCHEMA pya_apps AUTHORIZATION felipe;

-- DROP SEQUENCE pya_apps.config_id_seq;

CREATE SEQUENCE pya_apps.config_id_seq
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 2147483647
	START 1
	CACHE 1
	NO CYCLE;
-- DROP SEQUENCE pya_apps.software_id_seq;

CREATE SEQUENCE pya_apps.software_id_seq
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 2147483647
	START 1
	CACHE 1
	NO CYCLE;-- pya_apps.config definition

-- Drop table

-- DROP TABLE pya_apps.config;

CREATE TABLE pya_apps.config (
	id serial4 NOT NULL,
	"interval" numeric NULL,
	cleaning bool NULL
);


-- pya_apps.software definition

-- Drop table

-- DROP TABLE pya_apps.software;

CREATE TABLE pya_apps.software (
	id serial4 NOT NULL,
	descripcion text NULL,
	imagen text NULL,
	path_install text NULL,
	software text NULL,
	tag text NULL,
	url_msi text NULL,
	verifica_app text NULL,
	"version" text NULL,
	path_file text NULL,
	force_install bool NULL,
	automatic_install bool NULL,
	guid text NULL,
	grupos _text NULL,
	hidden bool NULL,
	CONSTRAINT software_pkey PRIMARY KEY (id)
);