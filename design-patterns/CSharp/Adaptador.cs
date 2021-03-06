/**
* Engenharia de Software Moderna - Padrões de Projeto (Cap. 6)
* Prof. Marco Tulio Valente
* 
* Exemplo do padrão de projeto Adaptador
*
*/

/**
* Classe concreta, representando um projetor da Samsung
*/
public class ProjetorSamsung
{

  public void turnOn()
  {
    System.Console.WriteLine("Ligando projetor da Samsung");
  }

}


/**
* Classe concreta, representando um projetor da LG
*/
public class ProjetorLG
{

  public void enable(int timer)
  {
    System.Console.WriteLine("Ligando projetor da LG em " + timer + " minutos");
  }

}

/**
* Interface para "abstrair" o tipo de projetor (Samsung ou LG)
*/
public interface Projetor
{
  void liga();
}

/**
* Adaptador de ProjetorSamsung para Projetor
* Um objeto da classe a seguir é um Projetor (pois implementa essa interface), 
* mas internamente repassa toda chamada de método para o objeto adaptado 
* (no caso, um ProjetorSamssung)
*/
public class AdaptadorProjetorSamsung : Projetor
{

  private ProjetorSamsung projetor;

  public AdaptadorProjetorSamsung(ProjetorSamsung projetor)
  {
    this.projetor = projetor;
  }

  public void liga()
  {
    projetor.turnOn(); // chama método do objeto adaptado (ProjetorSamsung)
  }

}


/**
* Idem classe anterior, mas agora adaptando ProjetoLG para Projetor 
*/
public class AdaptadorProjetorLG : Projetor
{

  private ProjetorLG projetor;

  public AdaptadorProjetorLG(ProjetorLG projetor)
  {
    this.projetor = projetor;
  }

  public void liga()
  {
    projetor.enable(0); // chama método de objeto adaptado (ProjetorLG)
  }

}


public class SistemaControleProjetores
{ // não tem conhecimento de "projetores concretos"

  public void init(Projetor projetor)
  {
    projetor.liga();  // liga qualquer projetor, sem precisar saber se é Samsung ou LG
  }

}

class Program
{

  public static void main(string[] args)
  {
    AdaptadorProjetorSamsung samsung = new AdaptadorProjetorSamsung(new ProjetorSamsung());
    AdaptadorProjetorLG lg = new AdaptadorProjetorLG(new ProjetorLG());
    SistemaControleProjetores scp = new SistemaControleProjetores();
    scp.init(samsung); // recebem como parâmetros objetos adaptadores, 
    scp.init(lg);      // que possuem internamente objetos (isto é, projetores) concretos
  }

}
