/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package prototipoaula;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.JOptionPane;

/**
 *
 * @author Bruno
 */
public class Dao {
   
    
        public void create(Mesa c){
	Connection con = ConnectionFactory.getConnection();
	PreparedStatement stmt = null;

        try {
            stmt = con.prepareStatement("insert into mesa (idmesa, capacidade, numeromesa) VALUES (?,?,?)");
            
            stmt.setInt(1, c.getIdmesa());  
            stmt.setInt(2, c.getCapacidade());
            stmt.setInt(3, c.getNumeromesa());

            stmt.executeUpdate(); 

               
           JOptionPane.showMessageDialog(null, "Salvo com sucesso!");
        } catch (SQLException ex) {
            JOptionPane.showMessageDialog(null, "Erro ao salvar!"+ex);
        }finally{
            ConnectionFactory.closeConnection((com.mysql.jdbc.Connection) con, stmt);
        }
    }
        
    public List<Mesa> read(){     // ler a tabela
        
	Connection con = ConnectionFactory.getConnection();
	PreparedStatement stmt = null;
	ResultSet rs = null;
        List<Mesa> r1980s = new ArrayList<>();
        
        try {
            stmt = con.prepareStatement("select * from mesa");
            rs = stmt.executeQuery();
            
            while(rs.next()){
                
                Mesa mesa = new Mesa();
                
                mesa.setIdmesa(rs.getInt("idmesa"));
                mesa.setCapacidade(rs.getInt("Capacidade"));
                mesa.setNumeromesa(rs.getInt("NumeroMesa"));
                
                r1980s.add(mesa);
                
            }
            
        } catch (SQLException ex) {
            Logger.getLogger(Dao.class.getName()).log(Level.SEVERE, null, ex);
        }finally{
            ConnectionFactory.closeConnection((com.mysql.jdbc.Connection) con, stmt, rs);
        }
        
        return r1980s;
    }
    
        public void update(Mesa c){      // atualizar
	Connection con = ConnectionFactory.getConnection();
	PreparedStatement stmt = null;

        try {
            stmt = con.prepareStatement("update mesa SET capacidade = ?, numeromesa = ? where idmesa = ?");

            stmt.setInt(1, c.getCapacidade());
            stmt.setInt(2, c.getNumeromesa());
            stmt.setInt(3, c.getIdmesa());
            
            stmt.executeUpdate();
               
           JOptionPane.showMessageDialog(null, "Atualizado com sucesso!");
        } catch (SQLException ex) {
            JOptionPane.showMessageDialog(null, "Erro ao atualizar!"+ex);
        }finally{
            ConnectionFactory.closeConnection((com.mysql.jdbc.Connection) con, stmt);
        }
    }
        
        public void delete(Mesa c){     //deletar
	Connection con = ConnectionFactory.getConnection();
	PreparedStatement stmt = null;

        try {
            stmt = con.prepareStatement("delete from mesa where idmesa = ?");

            stmt.setInt(1, c.getIdmesa());
            
            stmt.executeUpdate();
               
           JOptionPane.showMessageDialog(null, "Excluido com sucesso!");
        } catch (SQLException ex) {
            JOptionPane.showMessageDialog(null, "Erro ao excluir!"+ex);
        }finally{
            ConnectionFactory.closeConnection((com.mysql.jdbc.Connection) con, stmt);
        }
    }
   
    
    
}
