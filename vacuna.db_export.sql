BEGIN TRANSACTION;
DROP TABLE IF EXISTS "__EFMigrationsHistory";
CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
	"MigrationId"	TEXT NOT NULL,
	"ProductVersion"	TEXT NOT NULL,
	CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY("MigrationId")
);
DROP TABLE IF EXISTS "provincias";
CREATE TABLE IF NOT EXISTS "provincias" (
	"id"	INTEGER NOT NULL,
	"nombre"	TEXT NOT NULL,
	CONSTRAINT "PK_provincias" PRIMARY KEY("id" AUTOINCREMENT)
);
DROP TABLE IF EXISTS "vacunas";
CREATE TABLE IF NOT EXISTS "vacunas" (
	"id"	INTEGER NOT NULL,
	"marca"	TEXT NOT NULL,
	"cantidad_restante"	INTEGER NOT NULL,
	"cantidad_entrante"	INTEGER NOT NULL,
	CONSTRAINT "PK_vacunas" PRIMARY KEY("id" AUTOINCREMENT)
);
DROP TABLE IF EXISTS "vacunados";
CREATE TABLE IF NOT EXISTS "vacunados" (
	"id"	INTEGER NOT NULL,
	"cedula"	TEXT NOT NULL,
	"nombre"	TEXT NOT NULL,
	"fecha_nacimiento"	TEXT NOT NULL,
	"apellido"	TEXT NOT NULL,
	"telefono"	TEXT,
	"signo_zodiacal"	TEXT NOT NULL,
	"provincia_id"	INTEGER NOT NULL,
	"vacuna1_id"	INTEGER,
	"vacuna1_fecha"	TEXT,
	"vacuna2_id"	INTEGER,
	"vacuna2_fecha"	TEXT,
	"latitud"	REAL,
	"longitud"	REAL,
	CONSTRAINT "PK_vacunados" PRIMARY KEY("id" AUTOINCREMENT),
	CONSTRAINT "FK_vacunados_vacunas_vacuna2_id" FOREIGN KEY("vacuna2_id") REFERENCES "vacunas"("id") ON DELETE RESTRICT,
	CONSTRAINT "FK_vacunados_vacunas_vacuna1_id" FOREIGN KEY("vacuna1_id") REFERENCES "vacunas"("id") ON DELETE RESTRICT,
	CONSTRAINT "FK_vacunados_provincias_provincia_id" FOREIGN KEY("provincia_id") REFERENCES "provincias"("id") ON DELETE RESTRICT
);
INSERT INTO "__EFMigrationsHistory" VALUES ('20210306171740_initial','5.0.3');
INSERT INTO "provincias" VALUES (1,'Azua');
INSERT INTO "provincias" VALUES (2,'Bahoruco');
INSERT INTO "provincias" VALUES (3,'Barahona');
INSERT INTO "provincias" VALUES (4,'Dajabón');
INSERT INTO "provincias" VALUES (5,'Distrito Nacional');
INSERT INTO "provincias" VALUES (6,'Duarte');
INSERT INTO "provincias" VALUES (7,'Elías Piña');
INSERT INTO "provincias" VALUES (8,'El Seibo');
INSERT INTO "provincias" VALUES (9,'Espaillat');
INSERT INTO "provincias" VALUES (10,'Hato Mayor');
INSERT INTO "provincias" VALUES (11,'Hermanas Mirabal');
INSERT INTO "provincias" VALUES (12,'Independencia');
INSERT INTO "provincias" VALUES (13,'La Altagracia');
INSERT INTO "provincias" VALUES (14,'La Romana');
INSERT INTO "provincias" VALUES (15,'La Vega');
INSERT INTO "provincias" VALUES (16,'María Trinidad Sánchez');
INSERT INTO "provincias" VALUES (17,'Monseñor Nouel');
INSERT INTO "provincias" VALUES (18,'Monte Cristi');
INSERT INTO "provincias" VALUES (19,'Monte Plata');
INSERT INTO "provincias" VALUES (20,'Pedernales');
INSERT INTO "provincias" VALUES (21,'Peravia');
INSERT INTO "provincias" VALUES (22,'Puerto Plata');
INSERT INTO "provincias" VALUES (23,'Samaná');
INSERT INTO "provincias" VALUES (24,'San Cristóbal');
INSERT INTO "provincias" VALUES (25,'San José de Ocoa');
INSERT INTO "provincias" VALUES (26,'San Juan');
INSERT INTO "provincias" VALUES (27,'San Pedro de Macorís');
INSERT INTO "provincias" VALUES (28,'Sánchez Ramírez');
INSERT INTO "provincias" VALUES (29,'Santiago');
INSERT INTO "provincias" VALUES (30,'Santiago Rodríguez');
INSERT INTO "provincias" VALUES (31,'Santo Domingo');
INSERT INTO "provincias" VALUES (32,'Valverde');
INSERT INTO "vacunas" VALUES (1,'Astrazeneca',9999998,10000000);
INSERT INTO "vacunas" VALUES (2,'Pfizer',7899999,7900000);
INSERT INTO "vacunas" VALUES (3,'Sinovac',767999,768000);
INSERT INTO "vacunados" VALUES (3,'00117600825','AMADIS','1985-05-24 00:00:00','SUAREZ GENAO','8091237654','Geminis',31,1,'2021-03-06 00:00:00',2,'2021-04-04 00:00:00',NULL,NULL);
INSERT INTO "vacunados" VALUES (4,'40233681705','RODY','2001-06-15 00:00:00','CASTRO CUELLO','8292034247','Geminis',31,1,'2021-03-08 00:00:00',NULL,NULL,NULL,NULL);
INSERT INTO "vacunados" VALUES (5,'40210462848','EZEQUIEL','2001-11-13 00:00:00','PEREZ ROSARIO','8292141407','Escorpio',17,3,'2021-03-09 00:00:00',NULL,NULL,NULL,NULL);
DROP INDEX IF EXISTS "IX_vacunados_cedula";
CREATE UNIQUE INDEX IF NOT EXISTS "IX_vacunados_cedula" ON "vacunados" (
	"cedula"
);
DROP INDEX IF EXISTS "IX_vacunados_provincia_id";
CREATE INDEX IF NOT EXISTS "IX_vacunados_provincia_id" ON "vacunados" (
	"provincia_id"
);
DROP INDEX IF EXISTS "IX_vacunados_vacuna1_id";
CREATE INDEX IF NOT EXISTS "IX_vacunados_vacuna1_id" ON "vacunados" (
	"vacuna1_id"
);
DROP INDEX IF EXISTS "IX_vacunados_vacuna2_id";
CREATE INDEX IF NOT EXISTS "IX_vacunados_vacuna2_id" ON "vacunados" (
	"vacuna2_id"
);
DROP TRIGGER IF EXISTS "auto_vacunas_restantes_delete";
CREATE TRIGGER auto_vacunas_restantes_delete
   AFTER DELETE
   ON vacunados
BEGIN
	update vacunas set cantidad_restante = cantidad_restante + 1 where vacunas.id == old.vacuna1_id;
	update vacunas set cantidad_restante = cantidad_restante + 1 where vacunas.id == old.vacuna2_id;
END;
DROP TRIGGER IF EXISTS "auto_vacunas_restantes_insert";
CREATE TRIGGER auto_vacunas_restantes_insert
   AFTER INSERT
   ON vacunados
BEGIN
	update vacunas set cantidad_restante = cantidad_restante - 1 where vacunas.id == new.vacuna1_id;
	update vacunas set cantidad_restante = cantidad_restante - 1 where vacunas.id == new.vacuna2_id;
END;
DROP TRIGGER IF EXISTS "auto_vacunas_restantes_update";
CREATE TRIGGER auto_vacunas_restantes_update
   AFTER UPDATE
   ON vacunados
BEGIN
	update vacunas set cantidad_restante = cantidad_restante + 1 where vacunas.id == old.vacuna1_id;
	update vacunas set cantidad_restante = cantidad_restante - 1 where vacunas.id == new.vacuna1_id;
	update vacunas set cantidad_restante = cantidad_restante + 1 where vacunas.id == old.vacuna2_id;
	update vacunas set cantidad_restante = cantidad_restante - 1 where vacunas.id == new.vacuna2_id;
END;
COMMIT;
