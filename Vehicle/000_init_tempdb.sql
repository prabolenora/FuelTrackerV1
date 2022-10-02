CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220914173030_initial') THEN
    CREATE TABLE "Vehicles" (
        "Id" uuid NOT NULL,
        "vehicleRegistrationNumber" text NULL,
        "registeredDate" text NULL,
        "chassisNumber" text NULL,
        CONSTRAINT "PK_Vehicles" PRIMARY KEY ("Id")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220914173030_initial') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20220914173030_initial', '6.0.8');
    END IF;
END $EF$;
COMMIT;

