CREATE PROCEDURE USP_GetTablaPruebaPorId(
        @id bigint
) as 
select 
t.*, n.* 
from TablaPrueba t 
inner join REG_NivelSeveridad n ON t.IdNivelSeveridad = n.IdNivelSeveridad
where t.IdTablaPrueba = @id