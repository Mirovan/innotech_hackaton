//package ru.bigint.webapp.service.impl.game;
//
//
//import org.slf4j.Logger;
//import org.slf4j.LoggerFactory;
//import org.springframework.beans.factory.annotation.Autowired;
//import org.springframework.beans.factory.annotation.Qualifier;
//import org.springframework.stereotype.Service;
//import ru.bigint.data.dao.blog.PostDAO;
//import ru.bigint.data.entity.blog.Category;
//import ru.bigint.data.entity.blog.Post;
//import ru.bigint.service.iface.blog.PostService;
//
//import java.util.List;
//
//@Service("postService")
//public class PostServiceImpl implements PostService {
//
//    private final Logger LOGGER = LoggerFactory.getLogger(this.getClass());
//
//    @Autowired
//    @Qualifier("postDAO")
//    private PostDAO postDAO;
//
//    @Override
//    public Post getById(Integer id) {
//        return postDAO.findById(id).get();
//    }
//
//    @Override
//    public Post add(Post post) {
//        post = postDAO.save(post);
//        return post;
//    }
//
//    @Override
//    public Post update(Post post) {
//        post = postDAO.save(post);
//        return post;
//    }
//
//    @Override
//    public List<Post> getByCategory(Category category) {
//        List<Post> posts = postDAO.findByCategoryInOrderByCreatedate(category);
//        return posts;
//    }
//
//    @Override
//    public List<Post> getAll() {
//        return postDAO.findAll();
//    }
//}