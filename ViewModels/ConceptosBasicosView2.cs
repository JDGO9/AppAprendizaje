using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Proyect.Models;
using Proyect.Views;
using System.Collections.ObjectModel;
using Microsoft.Maui.Storage;

namespace Proyect.ViewModels
{
    public partial class ConceptosBasicosViewModel2 : ObservableObject
    {
       
        [ObservableProperty]
        private ObservableCollection<ConceptoModel> conceptos2;

        
        private bool _isSiguienteTemaHabilitado;
        public bool IsSiguienteTemaHabilitado
        {
            get => _isSiguienteTemaHabilitado;
            set => SetProperty(ref _isSiguienteTemaHabilitado, value);
        }

        public ConceptosBasicosViewModel2()
        {
            VerificarBloqueo();

            // Llenamos la lista con nuestros conceptos de electrónica
            Conceptos2 = new ObservableCollection<ConceptoModel>
            {
                new ConceptoModel
                {
                    Titulo = "1. ¿Qué es la Electricidad??????????",
                    Descripcion = "Para entender la electricidad a fondo, lo primero que debemos saber es que no es un invento del ser humano, ni tampoco es una especie de magia que sale de los enchufes de la pared. La electricidad es un fenómeno natural fundamental del universo. Está en todas partes: en un rayo durante una tormenta, en las neuronas de nuestro cerebro que nos permiten pensar, y en los dispositivos que usamos todos los días.\r\n\r\nPero, ¿qué es exactamente a nivel físico? En pocas palabras: es el movimiento y la interacción de unas partículas invisibles llamadas cargas eléctricas.\r\n\r\nPara comprender cómo funciona este fenómeno, tenemos que viajar al nivel más pequeño de la materia, descomponiendo todo lo que nos rodea hasta llegar a sus piezas de construcción básicas.",
                    Imagen = "electricidad.jpg"
                },
                new ConceptoModel
                {
                    Titulo = "2. Estructura del átomo",
                    Descripcion = "Todo lo que nos rodea (tu teléfono, una mesa, el agua, tu propio cuerpo) está formado por millones de millones de cosas microscópicas llamadas átomos.\r\n\r\nPara hacerlo fácil, imagina que cada átomo es como un mini sistema solar:\r\n\r\nEl Núcleo (El Centro): Está en el medio y tiene dos tipos de partículas:\r\n\r\nProtones: Tienen carga positiva (+). Son como imanes que atraen a los demás.\r\n\r\nNeutrones: No tienen carga (son neutros), solo están ahí para dar estabilidad.\r\n\r\nLos Electrones (Los satélites): Son partículas mucho más pequeñas que giran a toda velocidad alrededor del núcleo. Tienen carga negativa (-).\r\n\r\n💡 La regla de oro del átomo: Las cargas opuestas se atraen. Los protones positivos del centro atraen a los electrones negativos para que no se escapen. Sin embargo, los electrones que están más alejados del centro están \"flojitos\" y, si reciben un pequeño empujón, pueden saltar de un átomo a otro.",
                    Imagen = "atomo.jpg"
                },
                new ConceptoModel
                {
                    Titulo = "3. Flujo de electrones",
                    Descripcion = "Aquí es donde nace la electricidad.\r\n\r\nCuando logramos que esos electrones negativos salten de un átomo a otro y viajen en una misma dirección a través de un material, creamos un flujo de electrones. ¡Eso, exactamente, es la corriente eléctrica!\r\n\r\nLa analogía de las canicas en un tubo:\r\nImagina un tubo largo lleno de canicas (que representan los electrones). Si metes una canica nueva por un extremo, inmediatamente sale otra por el otro extremo. ¡El movimiento se transmite al instante! Así es como viaja la electricidad por un cable.\r\n\r\nConductores vs. Aislantes:\r\n\r\nConductores: Son materiales (como el cobre o el oro) cuyos átomos dejan que los electrones se muevan libremente. Por eso los cables por dentro son de metal.\r\n\r\nAislantes: Son materiales (como el plástico, la goma o la madera) cuyos átomos agarran fuerte a sus electrones y no los dejan moverse. Por eso los cables tienen una capa de plástico por fuera: para protegernos y que la electricidad no se escape.",
                    Imagen = "dotnet_bot.png"
                },
                new ConceptoModel
                {
                    Titulo = "4.Electricidad estática vs. Electricidad en corriente",
                    Descripcion = "Para terminar de entender qué es, vale la pena diferenciar las dos formas en que se manifiesta este fenómeno en nuestra vida diaria:\r\n\r\nElectricidad Estática (Cargas quietas):\r\nOcurre cuando las cargas eléctricas se acumulan en la superficie de un objeto. ¿Alguna vez has frotado un globo en tu cabello y se te ha quedado pegado, o has sentido una pequeña chispa al tocar la puerta del coche? Eso pasa porque al frotar arrancamos electrones de un material y los acumulamos en otro. Las cargas se quedan \"atrapadas\" (estáticas) hasta que encuentran por dónde escapar de golpe (la chispa).\r\n\r\nElectricidad en Corriente (Cargas en movimiento):\r\nEs la que usa la electrónica. Aquí las cargas no se acumulan para dar una chispa rápida, sino que fluyen de manera continua y controlada a través de un camino cerrado (un circuito) para hacer un trabajo útil: encender una pantalla, hacer girar un motor o transmitir datos en un microchip.",
                    Imagen = "dotnet_bot.png"
                },
                new ConceptoModel
                {
                    Titulo = "5.Magnitudes Eléctricas Fundamentales",
                    Descripcion = "Cuando hablamos de electricidad, no podemos simplemente decir \"hay mucha\" o \"hay poca\". Necesitamos medirla, controlarla y calcularla. Para eso existen las magnitudes eléctricas, que son las herramientas con las que medimos el comportamiento de los electrones.\r\n\r\nLas cuatro magnitudes principales que todo creador de circuitos debe dominar son: Voltaje, Corriente, Resistencia y Potencia.\r\n\r\nVamos a ver una por una usando la famosa analogía del agua.",
                    Imagen = "dotnet_bot.png"
                },
                new ConceptoModel
                {
                    Titulo = "6.Voltaje",
                    Descripcion = "¿Qué es en la realidad?\r\nEl voltaje es la fuerza, presión o empuje que obliga a los electrones a moverse a través de un cable. Sin voltaje, los electrones estarían quietos o moviéndose al azar sin un propósito. Es la diferencia de potencial eléctrico entre dos puntos. Se mide en Voltios (V).\r\n\r\nLa analogía del tanque de agua:\r\nImagina un tanque de agua elevado en un tejado. Cuanto más alto esté el tanque, mayor será la presión con la que el agua saldrá por la manguera de abajo. Esa presión de agua es exactamente el voltaje. Una pila de un control remoto tiene un voltaje pequeño (1.5V, poca presión), mientras que el enchufe de tu casa tiene un voltaje alto (120V o 220V, muchísima presión y peligro).",
                    Imagen = "dotnet_bot.png"
                },
                new ConceptoModel
                {
                    Titulo = "7.Corriente",
                    Descripcion = "¿Qué es en la realidad?\r\nLa corriente es la cantidad de electrones que pasan por un punto de un cable en un segundo. Es decir, es el flujo o caudal de la electricidad en movimiento. Se mide en Amperios (A).\r\n\r\nLa analogía del caudal de agua:\r\nSiguiendo con la manguera, la corriente es cuánta cantidad de agua sale por la boquilla por cada segundo. Si abres la llave a tope, hay mucha corriente (mucho caudal); si la abres apenas un hilito, hay poca corriente.\r\n\r\nNota clave: El voltaje es la presión que empuja el agua, y la corriente es el volumen de agua que realmente está fluyendo.",
                    Imagen = "dotnet_bot.png"
                },
                 new ConceptoModel
                {
                    Titulo = "8.Resistencia",
                    Descripcion = "¿Qué es en la realidad?\r\nLa resistencia es la oposición que ofrece un material al paso de los electrones. Algunos materiales ponen las cosas muy fáciles (los conductores), mientras que otros frenan casi por completo el paso de la electricidad. Se mide en Ohmios ($\\Omega$).La analogía de la tubería estrecha o la esponja:Imagina que a mitad de la manguera pones una zona muy estrecha, o colocas una esponja que traba el paso del agua. El agua costará más trabajo atravesarla. Eso es una resistencia.Si pones una alta resistencia, los electrones se frenan y pasa muy poca corriente.Si pones una baja resistencia, los electrones corren libremente y pasa mucha corriente.",
                    Imagen = "dotnet_bot.png"
                }, 
                new ConceptoModel
                {
                    Titulo = "9.Potencia",
                    Descripcion = "¿Qué es en la realidad?\r\nLa potencia es la cantidad de energía que un dispositivo consume o transforma por segundo (por ejemplo, cuánta energía convierte un foco en luz y calor, o un motor en movimiento). Se calcula multiplicando el voltaje por la corriente, y se mide en Vatios o Watts (W).\r\n\r\nLa analogía del trabajo del agua:\r\nImagina que usas el chorro de agua de la manguera para mover una pequeña rueda de molino. La potencia es qué tan fuerte hace girar esa rueda la combinación de la presión (voltaje) y el caudal (corriente). Un foco de 100 watts brilla mucho más que uno de 10 watts porque consume y transforma más potencia en el mismo tiempo.Resumen rápido para recordar:Voltaje (V): La presión que empuja.Corriente (A): El caudal que fluye.Resistencia ($\\Omega$): El freno que se opone.Potencia (W): El resultado del trabajo realizado.",
                    Imagen = "dotnet_bot.png"
                }
            };
        }

        // Método para comprobar si el examen ya fue aprobado anteriormente
        public void VerificarBloqueo()
        {
            IsSiguienteTemaHabilitado = Preferences.Get("TemaSiguienteDesbloqueado", false);
        }

        [RelayCommand]
        private async Task SiguienteTemaAsync()
        {
            await Shell.Current.DisplayAlert("¡Genial!", "Entrando al siguiente nivel", "OK");
            
        }

        [RelayCommand]
        private async Task IrAEvaluacionAsync()
        {

            await Shell.Current.GoToAsync(nameof(EvaluacionPage2));
        }
    }
}