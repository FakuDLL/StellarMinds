using StellarMinds.DTOs.DataTransferObjects;
using StellarMinds.LogicaNegocio.Entidades;

namespace StellarMinds.DTOs.Mappers
{
    public static class EquipoMapper
    {
        public static Equipo FromDtoAltaToEquipo(DTOAltaEquipo dto)
        {
            var tipo = (dto.TipoEquipo ?? string.Empty).Trim().ToLowerInvariant();

            return tipo switch
            {
                "telescopio" => new Telescopio(
                    dto.Marca,
                    dto.Modelo,
                    dto.CantidadDisponible,
                    dto.AperturaMm ?? throw new ArgumentException("AperturaMm es obligatoria para Telescopio."),
                    dto.RelacionFocal ?? throw new ArgumentException("RelacionFocal es obligatoria para Telescopio."),
                    dto.DistanciaFocalMm ?? throw new ArgumentException("DistanciaFocalMm es obligatoria para Telescopio."),
                    dto.PesoKg ?? throw new ArgumentException("PesoKg es obligatorio para Telescopio.")),

                "montura" => new Montura(
                    dto.Marca,
                    dto.Modelo,
                    dto.CantidadDisponible,
                    dto.TipoMontura ?? throw new ArgumentException("TipoMontura es obligatorio para Montura."),
                    dto.CargaUtilKg ?? throw new ArgumentException("CargaUtilKg es obligatoria para Montura."),
                    dto.EsComputarizado ?? false),

                "camara" => new Camara(
                    dto.Marca,
                    dto.Modelo,
                    dto.CantidadDisponible,
                    dto.TipoSensor ?? throw new ArgumentException("TipoSensor es obligatorio para Camara."),
                    dto.Resolucion ?? throw new ArgumentException("Resolucion es obligatoria para Camara."),
                    dto.TamanoPixelMicras ?? throw new ArgumentException("TamanoPixelMicras es obligatorio para Camara.")),

                "ocular" => new Ocular(
                    dto.Marca,
                    dto.Modelo,
                    dto.CantidadDisponible,
                    dto.DiametroMm ?? throw new ArgumentException("DiametroMm es obligatorio para Ocular."),
                    dto.AnguloVisionGrados ?? throw new ArgumentException("AnguloVisionGrados es obligatorio para Ocular.")),

                _ => throw new ArgumentException("Tipo de equipo no válido.")
            };
        }

        public static DTOEquipo FromEquipoToDto(Equipo equipo)
        {
            var dto = new DTOEquipo
            {
                Id = equipo.Id,
                Marca = equipo.Marca,
                Modelo = equipo.Modelo,
                CantidadDisponible = equipo.CantidadDisponible,
                TipoEquipo = equipo.GetType().Name
            };

            if (equipo is Telescopio telescopio)
            {
                dto.AperturaMm = telescopio.AperturaMm;
                dto.RelacionFocal = telescopio.RelacionFocal;
                dto.DistanciaFocalMm = telescopio.DistanciaFocalMm;
                dto.PesoKg = telescopio.PesoKg;
            }
            else if (equipo is Montura montura)
            {
                dto.TipoMontura = montura.TipoMontura;
                dto.CargaUtilKg = montura.CargaUtilKg;
                dto.EsComputarizado = montura.EsComputarizado;
            }
            else if (equipo is Camara camara)
            {
                dto.TipoSensor = camara.TipoSensor;
                dto.Resolucion = camara.Resolucion;
                dto.TamanoPixelMicras = camara.TamanoPixelMicras;
            }
            else if (equipo is Ocular ocular)
            {
                dto.DiametroMm = ocular.DiametroMm;
                dto.AnguloVisionGrados = ocular.AnguloVisionGrados;
            }

            return dto;
        }

        public static List<DTOEquipo> FromListEquipoToListDto(List<Equipo> equipos)
        {
            return equipos.Select(FromEquipoToDto).ToList();
        }

        public static DTOActualizarEquipo FromEquipoToDtoActualizar(Equipo equipo)
        {
            var dto = new DTOActualizarEquipo
            {
                Id = equipo.Id,
                Marca = equipo.Marca,
                Modelo = equipo.Modelo,
                CantidadDisponible = equipo.CantidadDisponible,
                TipoEquipo = equipo.GetType().Name
            };

            if (equipo is Telescopio telescopio)
            {
                dto.AperturaMm = telescopio.AperturaMm;
                dto.RelacionFocal = telescopio.RelacionFocal;
                dto.DistanciaFocalMm = telescopio.DistanciaFocalMm;
                dto.PesoKg = telescopio.PesoKg;
            }
            else if (equipo is Montura montura)
            {
                dto.TipoMontura = montura.TipoMontura;
                dto.CargaUtilKg = montura.CargaUtilKg;
                dto.EsComputarizado = montura.EsComputarizado;
            }
            else if (equipo is Camara camara)
            {
                dto.TipoSensor = camara.TipoSensor;
                dto.Resolucion = camara.Resolucion;
                dto.TamanoPixelMicras = camara.TamanoPixelMicras;
            }
            else if (equipo is Ocular ocular)
            {
                dto.DiametroMm = ocular.DiametroMm;
                dto.AnguloVisionGrados = ocular.AnguloVisionGrados;
            }

            return dto;
        }

        public static Equipo FromDtoActualizarToEquipo(DTOActualizarEquipo dto, Equipo existente)
        {
            existente.ActualizarDatosBase(dto.Marca, dto.Modelo, dto.CantidadDisponible);

            if (existente is Telescopio telescopio)
            {
                telescopio.ActualizarDatosTecnicos(
                    dto.AperturaMm ?? throw new ArgumentException("AperturaMm es obligatoria para Telescopio."),
                    dto.RelacionFocal ?? throw new ArgumentException("RelacionFocal es obligatoria para Telescopio."),
                    dto.DistanciaFocalMm ?? throw new ArgumentException("DistanciaFocalMm es obligatoria para Telescopio."),
                    dto.PesoKg ?? throw new ArgumentException("PesoKg es obligatorio para Telescopio."));
            }
            else if (existente is Montura montura)
            {
                montura.ActualizarDatosTecnicos(
                    dto.TipoMontura ?? throw new ArgumentException("TipoMontura es obligatorio para Montura."),
                    dto.CargaUtilKg ?? throw new ArgumentException("CargaUtilKg es obligatoria para Montura."),
                    dto.EsComputarizado ?? false);
            }
            else if (existente is Camara camara)
            {
                camara.ActualizarDatosTecnicos(
                    dto.TipoSensor ?? throw new ArgumentException("TipoSensor es obligatorio para Camara."),
                    dto.Resolucion ?? throw new ArgumentException("Resolucion es obligatoria para Camara."),
                    dto.TamanoPixelMicras ?? throw new ArgumentException("TamanoPixelMicras es obligatorio para Camara."));
            }
            else if (existente is Ocular ocular)
            {
                ocular.ActualizarDatosTecnicos(
                    dto.DiametroMm ?? throw new ArgumentException("DiametroMm es obligatorio para Ocular."),
                    dto.AnguloVisionGrados ?? throw new ArgumentException("AnguloVisionGrados es obligatorio para Ocular."));
            }

            return existente;
        }
    }
}
