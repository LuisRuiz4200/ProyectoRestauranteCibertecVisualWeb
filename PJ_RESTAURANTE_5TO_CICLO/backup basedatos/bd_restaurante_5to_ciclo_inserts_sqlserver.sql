use bd_restaurante_5to_ciclo 
go

insert into tb_tipo_usuario values ('CLIENTE') 
insert into tb_tipo_usuario values ('COLABORADOR') 
go

insert into tb_tipo_colaborador values ('MESERO') 
insert into tb_tipo_colaborador values ('COCINERO') 
insert into tb_tipo_colaborador values ('ADMINISTRADOR') 
insert into tb_tipo_colaborador values ('RECEPCIONISTA') 
insert into tb_tipo_colaborador values ('REPARTIDOR')
go


insert into tb_mediopago values ('TARJETA') 
insert into tb_mediopago values ('EFECTIVO') 
insert into tb_mediopago values ('YAPE') 
insert into tb_mediopago values ('PLIN') 
go

insert into tb_distrito values ('COMAS') 
insert into tb_distrito values ('CARABAYLLO') 
insert into tb_distrito values ('MIRAFLORES')
insert into tb_distrito values ('CHORRILLOS')
insert into tb_distrito values ('BARRANCA') 
insert into tb_distrito values ('ZURQUILLO') 
insert into tb_distrito values ('MAGDALENA') 
insert into tb_distrito values ('PUENTE PIEDRA') 
insert into tb_distrito values ('LOS OLIVOS') 
insert into tb_distrito values ('INDEPENDENCIA')
go

insert into tb_categoria_producto values ('BEBIDAS')
insert into tb_categoria_producto values ('PARRILLAS')
insert into tb_categoria_producto values ('MIXTOS')
insert into tb_categoria_producto values ('POLLOS')
insert into tb_categoria_producto values ('SNACKS')
insert into tb_categoria_producto values ('TRAGOS')
insert into tb_categoria_producto values ('OTROS')
go



