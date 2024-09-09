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
-- DROP SEQUENCE pya_apps.config_id_seq1;

CREATE SEQUENCE pya_apps.config_id_seq1
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
	NO CYCLE;
-- DROP SEQUENCE pya_apps.software_id_seq1;

CREATE SEQUENCE pya_apps.software_id_seq1
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 2147483647
	START 1
	CACHE 1
	NO CYCLE;
-- DROP SEQUENCE pya_apps.userpermissions_permissionid_seq;

CREATE SEQUENCE pya_apps.userpermissions_permissionid_seq
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 2147483647
	START 1
	CACHE 1
	NO CYCLE;
-- DROP SEQUENCE pya_apps.users_userid_seq;

CREATE SEQUENCE pya_apps.users_userid_seq
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
	software_name text NULL,
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
	actions int4 NULL,
	machines jsonb NULL,
	installername varchar NULL,
	CONSTRAINT software_pkey PRIMARY KEY (id)
);


-- pya_apps.users definition

-- Drop table

-- DROP TABLE pya_apps.users;

CREATE TABLE pya_apps.users (
	userid serial4 NOT NULL,
	username varchar(100) NOT NULL,
	CONSTRAINT users_pkey PRIMARY KEY (userid),
	CONSTRAINT users_username_key UNIQUE (username)
);


-- pya_apps.userpermissions definition

-- Drop table

-- DROP TABLE pya_apps.userpermissions;

CREATE TABLE pya_apps.userpermissions (
	permissionid serial4 NOT NULL,
	userid int4 NOT NULL,
	caneditapps bool DEFAULT false NULL,
	canviewusertab bool DEFAULT false NULL,
	CONSTRAINT uq_userpermissions UNIQUE (userid),
	CONSTRAINT userpermissions_pkey PRIMARY KEY (permissionid),
	CONSTRAINT userpermissions_userid_fkey FOREIGN KEY (userid) REFERENCES pya_apps.users(userid)
);