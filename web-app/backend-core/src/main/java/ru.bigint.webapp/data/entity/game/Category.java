//package ru.bigint.webapp.data.entity.blog;
//
//import java.util.List;
//
//@Entity
//@Table(name = "category")
//public class Category {
//    @Id
//    @GeneratedValue(strategy = GenerationType.IDENTITY)
//    @Column(name = "id")
//    private Integer id;
//
//    @Column(name = "name")
//    private String name;
//
//    @Column(name = "ordering")
//    private int ordering;
//
//    @OneToMany(
//            mappedBy = "category",
//            cascade = CascadeType.MERGE,
//            fetch = FetchType.LAZY
//    )
//    private List<Game> posts;
//
//    public Integer getId() {
//        return id;
//    }
//
//    public void setId(Integer id) {
//        this.id = id;
//    }
//
//    public String getName() {
//        return name;
//    }
//
//    public void setName(String name) {
//        this.name = name;
//    }
//
//    public int getOrdering() {
//        return ordering;
//    }
//
//    public void setOrdering(int ordering) {
//        this.ordering = ordering;
//    }
//
//    public List<Game> getPosts() {
//        return posts;
//    }
//
//    public void setPosts(List<Game> posts) {
//        this.posts = posts;
//    }
//}