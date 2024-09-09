-- INSERTA APLICACIONES
INSERT INTO pya_apps.software (id, descripcion, imagen, path_install, software_name, tag, url_msi, verifica_app, "version", path_file, force_install, automatic_install, guid, grupos, hidden, actions, machines, installername) 
VALUES(0, '7-Zip is a file archiver with a high compression ratio.', 'img', 'C:\Program Files\7-Zip\7-zip.dll', '7Zip', 'tag', 'D:\Users\Felipe\Downloads\7z2408-x64.msi', '', '2.4.0', 'C:\Program Files\7-Zip\7-zip.dll', false, false, 'd3624189-c096-4339-8d3d-1e0f91877888', '{Grupo1,Grupo2}', false, 0, '{}'::jsonb, '7z2408-x64.msi');

-- INSERTA USUARIOS
INSERT INTO pya_apps.users (userid, username) VALUES(1, 'Felipe');
INSERT INTO pya_apps.users (userid, username) VALUES(2, 'Admin');
INSERT INTO pya_apps.users (userid, username) VALUES(3, 'Pablo');

-- INSERTA PERMISOS
INSERT INTO pya_apps.userpermissions (permissionid, userid, caneditapps, canviewusertab) VALUES(1, 1, true, true);
INSERT INTO pya_apps.userpermissions (permissionid, userid, caneditapps, canviewusertab) VALUES(2, 2, true, true);
INSERT INTO pya_apps.userpermissions (permissionid, userid, caneditapps, canviewusertab) VALUES(3, 3, true, false);